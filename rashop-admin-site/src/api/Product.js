import axiosClient from "./axiosClient";

export const getProductAPI = (query, page, sortOrder) => {
    return axiosClient.post(`product/getproductadmin`, {
        query: query,
        page: page,
        sortOrder: sortOrder,
        PageSize: 8
    });
}