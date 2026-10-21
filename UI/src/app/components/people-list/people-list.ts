import { Component, inject, OnInit, signal } from '@angular/core';
import { PersonService } from '../../services/person';
import { Person } from '../../Models/person';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-people-list',
  standalone: true,
  imports: [RouterLink],
  templateUrl: './people-list.html',
  styleUrl: './people-list.css'
})
export class PeopleList implements OnInit {

  private personService = inject(PersonService);

  people = signal<Person[]>([]);
  loading = signal(true);
  errorMessage = signal('');

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
    if (!confirm('Are you sure you want to delete this person?')) {
      return;
    }

    this.personService.deletePerson(id).subscribe({
      next: () => {
        this.people.update(people => people.filter(person => person.id !== id));
      },
      error: (error) => {
        console.error(error);
        alert('Unable to delete person.');
      }
    });
  }
}