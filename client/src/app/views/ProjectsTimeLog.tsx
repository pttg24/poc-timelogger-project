import React, { Component } from 'react';
import ProjectsTimeLogTable from "../components/ProjectsTimeLogTable";
import ProjectTimeLogViewModel from '../models/projectTimeLogViewModel';
import { getProjectsTimeLog } from '../api/projectsTimeLog';
import {
    useLocation,
    useNavigate,
    useParams
} from "react-router-dom";

function withRouter(Component: any) {
    function ComponentWithRouterProp(props : any) {
        let location = useLocation();
        let navigate = useNavigate();
        let params = useParams();
        return (
            <Component
                {...props}
                router={{ location, navigate, params }}
            />
        );
    }

    return ComponentWithRouterProp;
}

class ProjectsTimeLog extends Component <{}, { projectsTimeLog: ProjectTimeLogViewModel; }> {
    private params: any;

    constructor(props: Readonly<{}>) {
        super(props);        
        this.state = { projectsTimeLog: new ProjectTimeLogViewModel() };
    }

    async componentDidMount() {
        this.params = this.props;
        const contributorItem = localStorage.getItem("contributor");
        const contributorNbr = contributorItem != null ? JSON.parse(contributorItem) : '';
        let id = this.params.router.params.projectId;
        await getProjectsTimeLog(id, contributorNbr)
            .then(response => {
                this.setState({ projectsTimeLog: response });
            })
            .catch(error => { console.log(error) })
    }


    render() {
        return (
            <>
                <div className="flex items-center my-6"></div>
                <div className="container mx-auto">
                    <div className="flex flex-wrap -mx-3 mb-2">
                        <div className="w-full md:w-1/3 px-3 mb-6 md:mb-0">
                            <label className="block uppercase tracking-wide text-gray-700 text-xl font-bold mb-2">
                                <p>Time entries - Details</p>
                                <p>Contributor: {this.state.projectsTimeLog.contributorNumber}</p>
                                <p>Project: {this.state.projectsTimeLog.projectNumber}</p>
                            </label>
                        </div>
                    </div>
                </div>

                <ProjectsTimeLogTable
                    projectsTimeLog={this.state.projectsTimeLog}
                    projectNumber={this.state.projectsTimeLog.projectNumber}
                    contributorNumber={this.state.projectsTimeLog.contributorNumber} />
            </>
        );
    }
}

export default withRouter(ProjectsTimeLog);