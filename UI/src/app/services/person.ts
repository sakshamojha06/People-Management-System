import { inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Person } from '../Models/person';
import { EducationLevel, Degree, Specialization } from '../Models/education';

@Injectable({
  providedIn: 'root'
})
export class PersonService {

  private http = inject(HttpClient);

  private apiUrl = 'http://localhost:5192/api';

  getPeople(): Observable<Person[]> {
    return this.http.get<Person[]>(`${this.apiUrl}/people`);
  }

  getPersonById(id: number): Observable<Person> {
    return this.http.get<Person>(`${this.apiUrl}/people/${id}`);
  }

  addPerson(person: Partial<Person>): Observable<Person> {
    return this.http.post<Person>(`${this.apiUrl}/people`, person);
  }

  updatePerson(id: number, person: Partial<Person>): Observable<void> {
    return this.http.put<void>(`${this.apiUrl}/people/${id}`, person);
  }

  deletePerson(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/people/${id}`);
  }

  getEducationLevels(): Observable<EducationLevel[]> {
    return this.http.get<EducationLevel[]>(`${this.apiUrl}/education/levels`);
  }

  getDegrees(id: number): Observable<Degree[]> {
    return this.http.get<Degree[]>(`${this.apiUrl}/education/degrees/${id}`);
  }

  getSpecializations(id: number): Observable<Specialization[]> {
    return this.http.get<Specialization[]>(`${this.apiUrl}/education/specializations/${id}`);
  }
}