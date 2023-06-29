export interface IStudent {
    id?: number,
    name: string,
    email: string,
    class: string,
    rollNo: number,
    password: string
    dateOfBirth: Date,
    dateOfAdmission: Date
}

export interface IEditStudent {
    id?: number;
    name: string;
    email: string;
    class: string;
    rollNo: number;
}