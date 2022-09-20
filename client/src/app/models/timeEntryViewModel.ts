export default class TimeEntryViewModel {
    id: number;
    contributorNumber: number;
    projectNumber: number;
    insertedAt: Date;
    entryDate: Date;
    entryDateStr: string;
    hours: number;
    notes: string;

    constructor() {
        this.id = 0;
        this.contributorNumber = 0;
        this.projectNumber = 0;
        this.insertedAt = new Date();
        this.entryDate = new Date();
        this.entryDateStr = '';
        this.hours = 0;
        this.notes = '';
    }
}