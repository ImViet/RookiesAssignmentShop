import React, { useEffect, useState } from "react";
import { Button } from "react-bootstrap";
import { getProductAPI } from "../api/Product"
function Product() {
    const [productsData, setProductsData] = useState();
    const [pageIndex, setPageIndex] = useState(1);
    const [sort, setSort] = useState("0");
    useEffect(()=>{
         getProductAPI("price_desc", pageIndex).then(res=>{setProductsData(res);console.log(res);}).catch(err=>console.log(err))
    },[pageIndex])
    

    return (
        <React.Fragment>
            <table className='table table-striped table-hover table-boredered' >
                <thead >
                    <tr>
                        <th scope='col'>Id</th>
                        <th scope='col'>Sản phẩm</th>
                        <th scope='col'>Giá</th>
                        <th scope='col'>Loại SP</th>
                        <th scope='col'>Ngày tạo</th>
                        <th></th>
                    </tr>
                </thead>
                <tbody>
                   {productsData && productsData.products.map(item => 
                        (
                            <tr key={item.productId}>
                                <td>{item.productId}</td>
                                <td>{item.productName}</td>
                                <td>{item.price}</td>
                                <td>{item.categoryName}</td>
                                <td>{item.dateCreated}</td>
                                <td>
                                    <Button variant="outline-primary">Chi tiết</Button>
                                    <Button variant="outline-warning">Sửa</Button>
                                    <Button variant="outline-danger">Xóa</Button>
                                </td>
                            </tr>
                        )
                    )}
                </tbody>
            <Button variant="outline-secondary" onClick={()=> setPageIndex((i)=>i-1)} size="xm">Trước</Button>
            <Button variant="outline-secondary" onClick={()=> setPageIndex((i)=>i+1)} >Sau</Button>
            </table>
        </React.Fragment>
    );
}

export default Product;