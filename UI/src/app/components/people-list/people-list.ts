import { Component, inject, OnInit, signal } from '@angular/core';
import { PersonService } from '../../services/person';
import { Person } from '../../Models/person';
import { RouterLink } from '@angular/router';
import { NotificationService } from '../../services/notification';

@Component({
  selector: 'app-people-list',
  standalone: true,
  imports: [RouterLink],
  templateUrl: './people-list.html',
  styleUrl: './people-list.css'
})
export class PeopleList implements OnInit {

  private personService = inject(PersonService);
  private notifications = inject(NotificationService);

  people = signal<Person[]>([]);
  loading = signal(true);
  errorMessage = signal('');
  deletePersonId = signal<number | null>(null);
  deleting = signal(false);

  ngOnInit(): void {
    this.loadPeople();
  }

  loadPeople(): void {
    this.personService.getPeople().subscribe({
      next: (data) => {
        this.people.set(data);
        this.loading.set(false);
      },
      error: (error) => {
        console.error(error);
        this.errorMessage.set('Unable to load people.');
        this.loading.set(false);
      }
    });
  }

  deletePerson(id: number): void {
    this.deletePersonId.set(id);
  }

  cancelDelete(): void {
    if (!this.deleting()) {
      this.deletePersonId.set(null);
    }
  }

  confirmDelete(): void {
    const id = this.deletePersonId();
    if (id === null || this.deleting()) {
      return;
    }

    this.deleting.set(true);
    this.personService.deletePerson(id).subscribe({
      next: () => {
        this.people.update(people => people.filter(person => person.id !== id));
        this.deletePersonId.set(null);
        this.deleting.set(false);
        this.notifications.show('Person deleted successfully.', 'success');
      },
      error: (error) => {
        console.error(error);
        this.deleting.set(false);
        this.notifications.show('Unable to delete person.', 'danger');
      }
    });
  }
}