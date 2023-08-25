import axios from 'axios'

const agileFoodFetch = axios.create({
    baseURL: "https://localhost:7240/api/v1",
    headers: {
        "Content-Type": "application/json",
        "Accept": "text/plain",
    },
});

export default agileFoodFetch