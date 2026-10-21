export interface EducationLevel {
  id: number;
  name: string;
}

export interface Degree {
  id: number;
  educationLevelId: number;
  name: string;
}

export interface Specialization {
  id: number;
  degreeId: number;
  name: string;
}