const BASE_URL = "http://localhost:3001";

export async function getAllProjects() {
    const response = await fetch(`${BASE_URL}/projects/all`);
    return response.json();
}

