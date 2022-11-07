import axiosClient from "./axiosClient";

export const getProductAPI = (query, page, sortOrder) => {
    return axiosClient.post(`product/getproductadmin`, {
        query: query,
        page: page,
        sortOrder: sortOrder,
        PageSize: 8
    });
}

export const postProductAPI = (newProduct) => {
    return axiosClient.post(`product/createproduct`, newProduct);
}

export const putProductAPI = (newProduct) => {
    return axiosClient.put(`product/editproduct`, newProduct);
}

export const deleteProductAPI = (id) => {
    return axiosClient.delete(`product/deleteproduct/${id}`);
}
