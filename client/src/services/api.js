import axios from 'axios';

const api = axios.create({
    baseURL:'htts://localhost:44300',
})

export default api;