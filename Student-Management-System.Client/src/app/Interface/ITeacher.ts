export interface ITeacher {
    id: number
    name: string,
    email: string,
    class: string,
    subject: string,
    qualification: string,
    salary: string,
    dob: Date,
    enrollmentDate: Date

}

export interface IEditTeacher {
    id: number,
    name: string,
    email: string
}