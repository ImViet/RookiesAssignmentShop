import axios from "axios";

const instance = axios.create({
    baseURL : 'https://localhost:7150/',
    timeout: 30000
});

instance.interceptors.response.use(
    (response) => {
        return response.data;
    },
    (error) =>{
        console.log(error);
    }
);

export default instance;