export interface IAdmin {
    id?: number;
    name: string;
    email: string;
    createdOn: Date;
}

export interface IAddAdmin {
    name: string,
    email: string,
    createdOn: Date
}