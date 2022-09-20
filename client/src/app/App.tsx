import * as React from "react";
import { BrowserRouter as Router,Routes, Route } from 'react-router-dom';
import Index from './views/Index';
import AddTimeEntry from './views/AddTimeEntry';
import Projects from "./views/Projects";
import ProjectsTimeLog from './views/ProjectsTimeLog';

import "./style.css";

export default function App() {
    return (
        <>
            <header className="bg-gray-900 text-white flex items-center h-12 w-full">
                <div className="container mx-auto">
                    <a className="navbar-brand" href="/">
                        Timelogger
                    </a>
                </div>
            </header>

            <main>
                <div className="container mx-auto">
                    <Router>
                        <Routes>
                            <Route path="/addtimeentry/" element={<AddTimeEntry />} />
                            <Route path="/projectstimelog/:projectId/" element={<ProjectsTimeLog />} />
                            <Route path="/projects/" element={<Projects />} />
                            <Route path="*" element={<Index />} />
                        </Routes>
                    </Router>
                </div>
            </main>
        </>
    );
}
