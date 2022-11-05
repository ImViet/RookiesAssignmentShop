import axiosClient from "./axiosClient";

export const getSubCategoryAPI = (query, page, sortOrder) => {
    return axiosClient.post(`subcate/getsubcategoryadmin`, {
        query: query,
        page: page,
        sortOrder: sortOrder,
        PageSize: 8
    });
}

export const postSubCategoryAPI = (newCategory) => {
    return axiosClient.post(`subcate/createsubcate`, newCategory);
}

export const deleteSubCategoryAPI = (id) => {
    return axiosClient.delete(`subcate/deletesubcategory/${id}`);
}

export const putSubCategoryAPI = (newCategory) => {
    return axiosClient.put(`subcate/editsubcategory`, newCategory);
}