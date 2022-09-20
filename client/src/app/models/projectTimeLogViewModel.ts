import TimeEntryViewModel from '../models/timeEntryViewModel';

export default class ProjectTimeLogViewModel {
    contributorNumber: number;
    projectNumber: number;
    timeEntries: TimeEntryViewModel[];

    constructor() {
        this.contributorNumber = 0;
        this.projectNumber = 0;
        this.timeEntries = [];
    }
}