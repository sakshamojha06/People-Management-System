import { Component, inject, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Router, RouterLink } from '@angular/router';
import { PersonService } from '../../services/person';
import { EducationLevel, Degree, Specialization } from '../../Models/education';

@Component({
  selector: 'app-add-person',
  standalone: true,
  imports: [FormsModule, RouterLink],
  templateUrl: './add-person.html',
  styleUrl: './add-person.css'
})
export class AddPerson implements OnInit {

  private service = inject(PersonService);
  private router = inject(Router);

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
    this.service.getEducationLevels().subscribe({
      next: data => this.educationLevels = data,
      error: () => this.errorMessage = 'Unable to load education levels.'
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

  savePerson(): void {
    if (!this.name.trim() || !this.educationLevelId ||
        !this.degreeId || !this.specializationId) {
      this.errorMessage = 'Please fill all fields.';
      return;
    }

    this.loading = true;
    this.errorMessage = '';

    this.service.addPerson({
      name: this.name.trim(),
      educationLevelId: this.educationLevelId,
      degreeId: this.degreeId,
      specializationId: this.specializationId
    }).subscribe({
      next: () => this.router.navigate(['/people']),
      error: () => {
        this.errorMessage = 'Unable to save person.';
        this.loading = false;
      }
    });
  }
}