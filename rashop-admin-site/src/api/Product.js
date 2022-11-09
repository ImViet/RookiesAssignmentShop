import axiosClient from "./axiosClient";

export const getProductAPI = (query, page, pageSize, sortOrder, cateId , subCateId) => {
    return axiosClient.post(`product/getproductadmin`, {
        query: query,
        page: page,
        sortOrder: sortOrder,
        PageSize: pageSize,
        cateId: cateId,
        subCateId: subCateId,
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
