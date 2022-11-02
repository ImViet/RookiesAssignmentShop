import axiosClient from "./axiosClient";

export const getCategoryAPI = (query, page, sortOrder) => {
    return axiosClient.post(`category/getcategoryadmin`, {
        query: query,
        page: page,
        sortOrder: sortOrder,
        PageSize: 2
    });
}