import React, { Component } from 'react';
import { Navigate } from 'react-router-dom';
import { saveProjectTimeLog } from '../api/projectsTimeLog';

export default class AddTimeEntry extends Component<{},
    { contributorNumber: number, projectNumber: number, entryDate:Date, hours: number, notes: string, saved: Boolean; post: Boolean }> {

    constructor(props: Readonly<{}>) {
        super(props);
        this.state = { contributorNumber: 0, projectNumber: 0, entryDate: new Date(), hours: 0, notes: '',  saved: false, post: false };
    }

    handleSave = (e: React.MouseEvent<HTMLButtonElement, MouseEvent>) => {
        e.preventDefault();

        saveProjectTimeLog(
            this.state.contributorNumber, this.state.projectNumber, this.state.entryDate, this.state.hours, this.state.notes)
            .then(result =>
                this.setState({ saved: true, post: result })
            )
            .catch(error => console.log(error));
    };

    updateContributorNumber = (e: React.ChangeEvent<HTMLInputElement>) => {
        this.setState({ contributorNumber: Number(e.target.value) });
    };
    updateProjectNumber = (e: React.ChangeEvent<HTMLInputElement>) => {
        this.setState({ projectNumber: Number(e.target.value) });
    };
    updateEntryDate = (e: React.ChangeEvent<HTMLInputElement>) => {
        this.setState({ entryDate: new Date(e.target.value) });
    };
    updateHours = (e: React.ChangeEvent<HTMLInputElement>) => {
        this.setState({ hours: Number(e.target.value) });
    };
    updateNotes = (e: React.ChangeEvent<HTMLInputElement>) => {
        this.setState({ notes: String(e.target.value) });
    };

    render() {
        if (this.state.saved) {
            return (
                <Navigate to={`/projectstimelog/${this.state.projectNumber}`} />
            );
        }

        return (
            <>
                <div className="container mx-auto">
                    <div className="flex items-center my-6">
                        <form>
                            <label className="py-2 px-4" htmlFor="contributorNumberInput">Contributor</label>
                            <input className="border py-2 px-4" type="number" id="contributorNumberInput" required={true} onChange={this.updateContributorNumber}/>
                            <label className="py-2 px-4" htmlFor="projectNumberInput">Project</label>
                            <input className="border py-2 px-4" type="number" id="projectNumberInput" required={true} onChange={this.updateProjectNumber}/>
                            <label className="py-2 px-4" htmlFor="entryDateInput">Date</label>
                            <input className="border py-2 px-4" type="date" id="entryDateInput" onChange={this.updateEntryDate}/>
                            <label className="py-2 px-4" htmlFor="hoursInput">Hours worked</label>
                            <input className="border py-2 px-4" type="number" id="hoursInput" required={true} onChange={this.updateHours}/>
                            <label className="py-2 px-4" htmlFor="notesInput">Notes</label>
                            <input className="border py-2 px-4" type="string" id="notesInput" required={false} onChange={this.updateNotes}/>
                            <div className="flex justify-end my-6">
                                <button className="bg-blue-500 hover:bg-blue-700 text-white font-bold py-2 px-4 rounded" onClick={this.handleSave}>Save</button>
                            </div>
                        </form>
                    </div>
                </div>
            </>
        );
    }
}