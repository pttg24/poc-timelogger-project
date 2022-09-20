import React, { Component } from 'react';
import ProjectsTable from "../components/ProjectsTable";
import ProjectsOverviewTable from "../components/ProjectsOverviewTable";
import ProjectViewModel from '../models/projectViewModel';
import ProjectOverviewViewModel from '../models/projectOverviewViewModel';
import { getAllProjects } from '../api/projects';
import { getProjectsTimeLogOverview } from '../api/projectsTimeLog';

function getDetails() {
    return `/addtimeentry`;
}

export function sortProjects(
    projects: ProjectViewModel[], sortAsc: Boolean): ProjectViewModel[] {
    const result = Array.from(projects);
    result.sort(sortAsc ?
        (stra, strb) => stringsSortAscending
            (stra.endDate.toString(), strb.endDate.toString()) : (stra, strb) => stringsSortDescending(stra.endDate.toString(), strb.endDate.toString()));
    return result;
}

function stringsSortAscending(stra: string, strb: string): number {
    const datea = new Date(stra);
    const dateb = new Date(strb);
    if (datea === dateb) {
        return 0;
    }

    return datea > dateb ? 1 : -1;
}

function stringsSortDescending(stra: string, strb: string): number {
    return stringsSortAscending(stra, strb) * -1;
}

export default class Projects extends Component<{}, { projects: ProjectViewModel[]; overview: ProjectOverviewViewModel[], sortAsc: Boolean; }> {

    constructor(props: Readonly<{}>) {
        super(props);
        this.state = { projects: [], overview: [], sortAsc: true };
    }

    async componentDidMount() {
        await getAllProjects()
            .then(response =>
            {
                this.setState({ projects: response });
            })
            .catch(error => { console.log(error) })

        const contributorItem = localStorage.getItem("contributor");
        const contributorNbr = contributorItem != null ? JSON.parse(contributorItem) : '';

        await getProjectsTimeLogOverview(contributorNbr)
            .then(response => {
                this.setState({ overview: response }); console.log(this.state.overview);
            })
            .catch(error => { console.log(error) })
    }

    sortByDeadline = () => {
        const sortAsc = this.state.sortAsc;
        const projects = sortProjects(this.state.projects, this.state.sortAsc);
        this.setState({ projects, sortAsc: !sortAsc });
    };

    render() {

        return (
            <>
                <div className="flex items-center my-6">
                    <div className="w-1/2">

                        <a href={getDetails()}>
                            <input type="button" className="bg-blue-500 hover:bg-blue-700 text-white font-bold py-2 px-4 rounded" value="Add time entry" />
                        </a>
                    </div>

                    <div className="w-1/2 flex justify-end">
                        <form>
                            <input
                                className="border rounded-full py-2 px-4"
                                type="search"
                                placeholder="Search"
                                aria-label="Search"
                            />
                            <button
                                className="bg-blue-500 hover:bg-blue-700 text-white rounded-full py-2 px-4 ml-2"
                                type="submit"
                            >
                                Search
                            </button>
                        </form>
                    </div>
                </div>

                <ProjectsTable projects={this.state.projects} sortByDeadline={this.sortByDeadline} />

                <div className="flex items-center my-6">
                    <div className="container mx-auto">
                        <div className="flex flex-wrap -mx-3 mb-2">
                            <div className="w-full md:w-1/2 px-3 mb-4 md:mb-0">
                                <label className="block uppercase tracking-wide text-gray-700 text-xl font-bold mb-2">
                                    <span>My overview</span>
                                </label>
                                <label className="block uppercase tracking-wide text-gray-700 text-xs font-bold mb-2">
                                    <span>Hours submitted per project</span>
                                </label>
                            </div>
                        </div>
                    </div>
                </div>

                <ProjectsOverviewTable overview={this.state.overview} />
                
            </>
        );
    }
}