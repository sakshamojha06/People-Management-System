import { ComponentFixture, TestBed } from '@angular/core/testing';
import { provideRouter } from '@angular/router';
import { of } from 'rxjs';
import { PersonService } from '../../services/person';
import { PeopleList } from './people-list';

describe('PeopleList', () => {
  let component: PeopleList;
  let fixture: ComponentFixture<PeopleList>;
  const people = [
    {
      id: 1,
      name: 'Ada Lovelace',
      educationLevelId: 1,
      educationLevel: 'Graduate',
      degreeId: 1,
      degree: 'Mathematics',
      specializationId: 1,
      specialization: 'Computing',
    },
  ];

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [PeopleList],
      providers: [
        provideRouter([]),
        {
          provide: PersonService,
          useValue: { getPeople: () => of(people) },
        },
      ],
    }).compileComponents();

    fixture = TestBed.createComponent(PeopleList);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should render people as soon as the API response arrives', async () => {
    fixture.detectChanges();
    await fixture.whenStable();

    expect(fixture.nativeElement.textContent).toContain('Ada Lovelace');
    expect(fixture.nativeElement.textContent).not.toContain('Loading people...');
  });
});
