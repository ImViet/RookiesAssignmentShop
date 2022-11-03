import { useEffect, useState } from "react";
import { Button, Form } from "react-bootstrap";
import {postCategoryAPI} from "../../../api/Category"
function AddCategoryForm(){
    const [cate, setCate] = useState({cateName: "", description:"", image:""});
    const handleSubmit = async (e) =>{
        e.preventDefault();
    }
    return(
        <Form onSubmit={handleSubmit}>
            <Form.Group className="mt-2">
                <Form.Control 
                    name="cateName"
                    type = "text"
                    placeholder = "Tên danh mục..."
                    required
                />
            </Form.Group>
            <Form.Group className="mt-2">
                <Form.Control 
                    as = "textarea"
                    name="description"
                    placeholder = "Mô tả..."
                    row={3}     
                />
            </Form.Group>
            <Form.Group className="mt-2"> 
                <Form.Control 
                    type = "file" 
                    name="image"
                />
            </Form.Group>
            <Button className="mt-5" variant="success" type="submit" block>
                Tạo
            </Button>
        </Form>
    );
}
export default AddCategoryForm;