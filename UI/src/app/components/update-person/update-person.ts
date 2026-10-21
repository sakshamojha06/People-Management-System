import { Component, inject, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { ActivatedRoute, Router, RouterLink } from '@angular/router';
import { PersonService } from '../../services/person';
import { EducationLevel, Degree, Specialization } from '../../Models/education';

@Component({
  selector: 'app-update-person',
  standalone: true,
  imports: [FormsModule, RouterLink],
  templateUrl: './update-person.html',
  styleUrl: './update-person.css'
})
export class UpdatePerson implements OnInit {

  private service = inject(PersonService);
  private route = inject(ActivatedRoute);
  private router = inject(Router);

  id = 0;
  name = '';
  educationLevelId = 0;
  degreeId = 0;
  specializationId = 0;

  educationLevels: EducationLevel[] = [];
  degrees: Degree[] = [];
  specializations: Specialization[] = [];

  loading = false;
  errorMessage = '';

  ngOnInit(): void {
    this.id = Number(this.route.snapshot.paramMap.get('id'));

    this.service.getEducationLevels().subscribe({
      next: levels => {
        this.educationLevels = levels;
        this.loadPerson();
      },
      error: () => this.errorMessage = 'Unable to load education levels.'
    });
  }

  loadPerson(): void {
    this.service.getPersonById(this.id).subscribe({
      next: person => {
        this.name = person.name;
        this.educationLevelId = person.educationLevelId;

        this.service.getDegrees(this.educationLevelId).subscribe({
          next: degrees => {
            this.degrees = degrees;
            this.degreeId = person.degreeId;

            this.service.getSpecializations(this.degreeId).subscribe({
              next: specializations => {
                this.specializations = specializations;
                this.specializationId = person.specializationId;
              },
              error: () => this.errorMessage = 'Unable to load specializations.'
            });
          },
          error: () => this.errorMessage = 'Unable to load degrees.'
        });
      },
      error: () => this.errorMessage = 'Unable to load person.'
    });
  }

  onEducationLevelChange(): void {
    this.degreeId = 0;
    this.specializationId = 0;
    this.degrees = [];
    this.specializations = [];

    if (this.educationLevelId) {
      this.service.getDegrees(this.educationLevelId).subscribe({
        next: data => this.degrees = data,
        error: () => this.errorMessage = 'Unable to load degrees.'
      });
    }
  }

  onDegreeChange(): void {
    this.specializationId = 0;
    this.specializations = [];

    if (this.degreeId) {
      this.service.getSpecializations(this.degreeId).subscribe({
        next: data => this.specializations = data,
        error: () => this.errorMessage = 'Unable to load specializations.'
      });
    }
  }

  updatePerson(): void {
    if (!this.name.trim() || !this.educationLevelId ||
        !this.degreeId || !this.specializationId) {
      this.errorMessage = 'Please fill all fields.';
      return;
    }

    this.loading = true;
    this.errorMessage = '';

    this.service.updatePerson(this.id, {
      name: this.name.trim(),
      educationLevelId: this.educationLevelId,
      degreeId: this.degreeId,
      specializationId: this.specializationId
    }).subscribe({
      next: () => this.router.navigate(['/people']),
      error: () => {
        this.errorMessage = 'Unable to update person.';
        this.loading = false;
      }
    });
  }
}