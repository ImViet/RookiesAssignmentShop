import { useEffect, useState } from "react";
import { Button, Form } from "react-bootstrap";
import { postCategoryAPI } from "../../../api/Category";
function AddCategoryForm() {
  const [cate, setCate] = useState({
    cateName: "",
    description: "",
    image: "",
  });
  function handleSubmit(e) {
    // e.preventDefault();
    console.log(cate);
    postCategoryAPI(cate);
  }
  const setValues = (e) => {
    setCate((previousState) => {
      return { ...previousState, [e.target.name]: e.target.value };
    });
  };

  return (
    <Form onSubmit={handleSubmit}>
      <Form.Group className="mt-2">
        <Form.Control
          name="cateName"
          type="text"
          placeholder="Tên danh mục..."
          onChange={setValues}
          required
        />
      </Form.Group>
      <Form.Group className="mt-2">
        <Form.Control
          as="textarea"
          name="description"
          placeholder="Mô tả..."
          onChange={setValues}
          row={3}
        />
      </Form.Group>
      <Form.Group className="mt-2">
        <Form.Control type="file" name="image" onChange={setValues} />
      </Form.Group>
      <Button className="mt-5" variant="success" type="submit">
        Tạo
      </Button>
    </Form>
  );
}
export default AddCategoryForm;
