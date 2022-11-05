import axiosClient from "./axiosClient";

export const getCategoryAPI = (query, page, sortOrder) => {
    return axiosClient.post(`category/getcategoryadmin`, {
        query: query,
        page: page,
        sortOrder: sortOrder,
        PageSize: 8
    });
}

export const getCategorySelect = () => {
    return axiosClient.get(`category/getallcategory`);
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