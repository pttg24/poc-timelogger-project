import React from "react";
import ProjectTimeLogViewModel from '../models/projectTimeLogViewModel';

export default function ProjectsTimeLogTable(props: { projectsTimeLog: ProjectTimeLogViewModel, projectNumber: number, contributorNumber: number  }) {

	props.projectsTimeLog.timeEntries.forEach(p =>
		p.entryDateStr = new Date(p.entryDate).toLocaleDateString()
	);

	return (
		<table className="table-fixed w-full">
			<thead className="bg-gray-200">
				<tr>
					<th className="border px-4 py-2 w-12">#</th>
					<th className="border px-4 py-2">Contributor</th>
					<th className="border px-4 py-2">Project</th>
					<th className="border px-4 py-2">Entry Date</th>
					<th className="border px-4 py-2">Hours Logged</th>
					<th className="border px-4 py-2">Notes</th>
					<th className="border px-4 py-2">Created On</th>
				</tr>
			</thead>

			<tbody>
				{props.projectsTimeLog.timeEntries.map((entry, index) =>
					<tr key={index}>
						<td className="border px-4 py-2 w-12">{index + 1}</td>
						<td className="border px-4 py-2">{entry.contributorNumber}</td>
						<td className="border px-4 py-2">{entry.projectNumber}</td>
						<td className="border px-4 py-2">{(entry.entryDateStr)}</td>
						<td className="border px-4 py-2">{entry.hours}</td>
						<td className="border px-4 py-2">{entry.notes}</td>
						<td className="border px-4 py-2">{entry.insertedAt}</td>
					</tr>)}
				
			</tbody>		
		</table>
	);
}