import { useEffect, useState } from "react";
import { Button, Form } from "react-bootstrap";
import { putCategoryAPI } from "../../../api/Category";

function EditCategoryForm({ data }) {
  const [cate, setCate] = useState({
    cateId: data.categoryId,
    cateName: data.categoryName,
    description: data.description,
    image: data.image,
  });
  const setValues = (e) => {
    setCate((previousState) => {
      return { ...previousState, [e.target.name]: e.target.value };
    });
  };
  function handleSubmit(e) {
    // e.preventDefault();
    console.log(cate);
    putCategoryAPI(cate);
  }
  return (
    <Form onSubmit={handleSubmit}>
      <Form.Group className="mt-2">
        <Form.Control
          name="cateName"
          type="text"
          placeholder="Tên danh mục..."
          required
          defaultValue={data.categoryId}
          disabled={true}
        />
      </Form.Group>
      <Form.Group className="mt-2">
        <Form.Control
          name="cateName"
          type="text"
          placeholder="Tên danh mục..."
          required
          defaultValue={data.categoryName}
          onChange={setValues}
        />
      </Form.Group>
      <Form.Group className="mt-2">
        <Form.Control
          as="textarea"
          name="description"
          placeholder="Mô tả..."
          row={3}
          defaultValue={data.description}
          onChange={setValues}
        />
      </Form.Group>
      <Form.Group className="mt-2">
        <Form.Control
          type="file"
          name="image"
          placeholder="Chon anh"
          onChange={setValues}
        />
      </Form.Group>
      <Button className="mt-5" variant="success" type="submit" block>
        Xong
      </Button>
    </Form>
  );
}
export default EditCategoryForm;
