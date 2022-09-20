import React from "react";
import ProjectViewModel from '../models/projectViewModel';

function getDetails(projectId: number) {
    return `/projectstimelog/${projectId}`;
}

export default function ProjectsTable(props: { projects: ProjectViewModel[]; sortByDeadline: any; }) {

    props.projects.forEach(p => p.endDateStr = new Date(p.endDate).toLocaleDateString());

    return (
        <table className="table-fixed w-full">
            <thead className="bg-blue-500 text-white">
                <tr>
                    <th className="border px-4 py-2 w-12">#</th>
                    <th className="border px-4 py-2">Project Name</th>
                    <th className="border px-4 py-2">Customer</th>
                    <th className="border px-4 py-2">Price</th>
                    <th className="border px-4 py-2 bg-emerald-500" onClick={props.sortByDeadline}>Deadline</th>
                    <th className="border px-4 py-2">Finished ?</th>
                    <th className="border px-4 py-2">Contributor</th>
                    <th className="border px-4 py-2">Notes</th>
                    <th className="border px-4 py-2">Details</th>
                </tr>
            </thead>
			<tbody>
				{props.projects.map((project, index) =>
					<tr key={index}>
						<td className="border px-4 py-2 w-12">{index + 1}</td>
						<td className="border px-4 py-2">{project.name}</td>
						<td className="border px-4 py-2">{project.customerNumber}</td>
                        <td className="border px-4 py-2">{project.price}</td>
                        <td className="border px-4 py-2">{project.endDateStr}</td>
                        <td className="border px-4 py-2">{project.isFinished.toString()}</td>
                        <td className="border px-4 py-2">{project.contributorNumber}</td>
                        <td className="border px-4 py-2">{project.notes}</td>
                        <td className="border px-4 py-2">
                            <a href={getDetails(project.number)}>
                                <input type="button" className="shadow bg-emerald-500 font-bold py-2 px-4 border border-emerald-500 rounded text-slate-100 hover:text-blue-800" value="Hours Logged" />
                            </a>
                        </td>
					</tr>)}
			</tbody>
        </table>
    );
}
