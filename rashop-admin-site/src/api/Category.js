import axiosClient from "./axiosClient";

export const getCategoryAPI = (query, page, sortOrder) => {
    return axiosClient.post(`category/getcategoryadmin`, {
        query: query,
        page: page,
        sortOrder: sortOrder,
        PageSize: 2
    });
}

export const postCategoryAPI = (newCategory) => {
    return axiosClient.post(`category/createcate`, newCategory);
}

export const deleteCategoryAPI = (id) => {
    return axiosClient.delete(`category/deletecategory/${id}`);
}

export const putCategoryAPI = (newCategory) => {
    return axiosClient.put(`category/editcategory`, newCategory);
}