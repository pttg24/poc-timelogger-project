import React, { Component } from 'react';

function goToProjects(contributor: number) {
    localStorage.setItem("contributor", JSON.stringify(contributor));
    if (contributor == null || contributor <= 0)
        return '/index';
    else
        return `/projects`;
}

export default class Index extends Component<{}, { contributorNumber: number }> {

    constructor(props: Readonly<{}>) {
        super(props);
        this.state = { contributorNumber: 0 };
    }

    updateContributorNumber = (e: React.ChangeEvent<HTMLInputElement>) => {
        this.setState({ contributorNumber: Number(e.target.value) });
    };

    render() {

        return (
            <>
                <main>
                    <div className="flex items-center my-6">
                        <div className="container mx-auto">
                            <div className="flex flex-wrap -mx-3 mb-2">
                                <div className="w-full md:w-1/2 px-3 mb-4 md:mb-0">
                                    <label className="block uppercase tracking-wide text-gray-700 text-xl font-bold mb-2">
                                        <span>Timelogger Homepage, welcome!</span>
                                    </label>
                                </div>
                            </div>                        
                        </div>
                        <label className="py-2 px-4" htmlFor="contributorInput">Contributor Number</label>
                        <input className="border py-2 px-4" type="number" id="contributorInput" onChange={this.updateContributorNumber} />
                        <a href={goToProjects(this.state.contributorNumber)}>
                            <input type="button" className="shadow bg-blue-500 font-bold py-2 px-4 border border-blue-500 rounded text-slate-100 hover:text-blue-800" value=" Go To Projects >>>" />
                        </a>
                    </div>
                </main>
            </>
        );
    }
}