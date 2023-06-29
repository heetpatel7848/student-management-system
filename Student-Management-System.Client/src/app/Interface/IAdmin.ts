export interface IAdmin {
    id?: number;
    name: string;
    email: string;
    createdOn: Date;
    password: string;
}

export interface IAddAdmin {
    name: string,
    email: string,
    createdOn: Date
}

export interface IEditAdmin {
    id?: number;
    name: string;
    email: string;
    createdOn: Date;
    password: string;
}
