import { useEffect, useState } from "react";
import { getProductAPI } from "../api/Product"

const Product = () =>{
    const [product, setProduct] = useState([])
    useEffect(() => {
        getProductAPI()},[])

// const data = getProductAPI();
function Product() {
    console.log(data)
    return (
        <div>
            <h4>{data.totalpages}</h4>
            <table className='table table-success table-striped table-hover table-boredered' >
                <thead >
                    <tr>
                        <th scope='col'>ProjectName</th>
                        <th scope='col'>GithubLink</th>
                        <th scope='col'>URLLink</th>
                        <th scope='col'> ImageName</th>
                        <th scope='col'>ImageName</th>
                        <th scope='col'>Action</th>
                    </tr>
                </thead>

            </table>
        </div>
    );
}

export default Product;