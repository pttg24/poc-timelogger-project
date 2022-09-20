import TimeEntryViewModel from '../models/timeEntryViewModel';

const BASE_URL = "http://localhost:3001";

export async function getProjectsTimeLog(projectNumber: number, contributorNumber: number) {
    const response = await fetch(`${BASE_URL}/timeentries?project=${projectNumber}&contributor=${contributorNumber}`);
    return response.json();
}

export async function getProjectsTimeLogOverview(contributorNumber: number) {
    const response = await fetch(`${BASE_URL}/timeentries/overview/${contributorNumber}`);
    return response.json();
}

export async function saveProjectTimeLog(contributorNumber: number, projectNumber: number, entryDate: Date, hours: number, notes: string): Promise<boolean> {

    const timeEntry = new TimeEntryViewModel();
    timeEntry.contributorNumber = contributorNumber;
    timeEntry.entryDate = entryDate,
    timeEntry.id = Math.floor(Math.random() * 300) + 1,
    timeEntry.projectNumber = projectNumber,
    timeEntry.hours = hours,
    timeEntry.notes = notes

    const response = await fetch(`${BASE_URL}/TimeEntries`, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        mode: 'cors',
        credentials: 'include',
        body: JSON.stringify(timeEntry)
    });
    return response.status === 204;
}
