export default class ProjectViewModel {
    number: number;
    name: string;
    contributorNumber: number;
    customerNumber: number;
    endDate: Date;
    endDateStr: string;
    isFinished: boolean;
    price: number;
    notes: string;

    constructor() {
        this.number = 0;
        this.name = '';
        this.contributorNumber = 0;
        this.customerNumber = 0;
        this.endDate = new Date();
        this.isFinished = true;
        this.price = 0;
        this.notes = '';
        this.endDateStr = '';
    }   
}