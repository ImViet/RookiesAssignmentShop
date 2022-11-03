import { Button, Form } from "react-bootstrap";

function EditCategoryForm({data}){
    return(
        <Form>
            <Form.Group className="mt-2">
                <Form.Control 
                    name="categoryName"
                    type = "text"
                    placeholder = "Tên danh mục..."
                    required
                    defaultValue={data.categoryName}
                />
            </Form.Group>
            <Form.Group className="mt-2">
                <Form.Control 
                    as = "textarea"
                    placeholder = "Mô tả..."
                    row={3}     
                    defaultValue={data.description}
                />
            </Form.Group>
            <Form.Group className="mt-2"> 
                <Form.Control 
                    type = "file"
                    placeholder = "Chon anh"    
                />
            </Form.Group>
            <Button className="mt-5" variant="success" type="submit" block>
                Xong
            </Button>
        </Form>
    );
}
export default EditCategoryForm;