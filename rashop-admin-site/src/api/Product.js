import axiosClient from "./axiosClient";


const END_POINT = {
    GETPRODUCT: "product/getallproduct?sort=0&pagecurrent=1",
}
export const getProductAPI  = () =>
{
    return axiosClient.get(END_POINT.GETPRODUCT);
}