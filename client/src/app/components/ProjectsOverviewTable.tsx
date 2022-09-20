import React from "react";
import ProjectOverviewViewModel from '../models/projectOverviewViewModel';

export default function ProjectsOverviewTable(props: { overview: ProjectOverviewViewModel[]; }) {

    return (
        <table className="table-fixed w-full">
            <thead className="bg-gray-500 text-white">
                <tr>
                    <th className="border px-4 py-2 w-12">#</th>
                    <th className="border px-4 py-2">Project ID</th>
                    <th className="border px-4 py-2">Hours Worked</th>
                </tr>
            </thead>
            <tbody>
                {props.overview.map((ov, index) =>
                    <tr key={index}>
                        <td className="border px-4 py-2 w-12">{index + 1}</td>
                        <td className="border px-4 py-2">{ov.projectNumber}</td>
                        <td className="border px-4 py-2">{ov.hours} hours</td>
                    </tr>)}
            </tbody>
        </table>
    );
}
