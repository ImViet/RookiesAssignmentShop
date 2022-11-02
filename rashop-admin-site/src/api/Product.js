import axiosClient from "./axiosClient";


const END_POINT = {
    GETPRODUCT: (sort, page) =>{

        return`product/getallproduct?sort=${sort}&pagecurrent=${page}`;
    }
}
export const getProductAPI = (sort, page) =>
{
    return axiosClient.get(END_POINT.GETPRODUCT(sort, page));
}