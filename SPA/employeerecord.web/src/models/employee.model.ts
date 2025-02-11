export interface Employee {
    id: string;
    fullname: string;
    firstname: string;
    lastname: string;
    middlename: string;
    gender: string;
    dateofBirth: Date;
    email: string | null;
    phoneNumber: string | null;
    homeAddress: string | null;
    isActive: boolean;

}