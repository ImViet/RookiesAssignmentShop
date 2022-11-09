import axios from "axios";

const instance = axios.create({
    baseURL : 'https://localhost:7150/'
});

instance.interceptors.response.use(
    (response) => {
        return response.data;
    },
    (error) =>{
        return Promise.reject(error).response.data;
    }
);

export default instance;