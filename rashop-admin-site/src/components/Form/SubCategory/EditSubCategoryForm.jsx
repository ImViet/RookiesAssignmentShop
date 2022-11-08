import React, { useState, useEffect } from "react";
import { putSubCategoryAPI } from "../../../api/SubCategory";
import { getCategorySelect } from "../../../api/Category";
import { Form, Col } from "react-bootstrap";
import {
  MDBValidation,
  MDBValidationItem,
  MDBInput,
  MDBBtn,
  MDBTextArea,
} from "mdb-react-ui-kit";
function EditSubCategoryForm({ data, onSubmit }) {
  const [subCate, setSubCate] = useState({
    subCateId: data.subCategoryId,
    subCateName: data.subCategoryName,
    description: data.description,
    categoryParentId: data.categoryParentId,
  });
  const [categoriesData, setCatesData] = useState();
  const setValues = (e) => {
    setSubCate((previousState) => {
      return { ...previousState, [e.target.name]: e.target.value };
    });
  };
  function handleSubmit(e) {
    if (subCate.subCateName !== "" && subCate.categoryId !== "0") {
      e.preventDefault();
      console.log(subCate);
      putSubCategoryAPI(subCate);
      onSubmit(subCate);
    } else console.log(subCate.categoryId);
  }

  useEffect(() => {
    getCategorySelect()
      .then((res) => {
        setCatesData(res);
      })
      .catch((err) => console.log(err));
  }, []);
  return (
    <React.Fragment>
      <MDBValidation onSubmit={handleSubmit} className="row g-3">
        <MDBValidationItem className="col-md-12">
          <MDBInput
            name="subCateId"
            id="subCateId"
            size="lg"
            label="Id"
            defaultValue={data.subCategoryId}
            maxLength={50}
            required
            disabled
          />
        </MDBValidationItem>
        <MDBValidationItem tooltip className="col-md-12">
          <MDBInput
            onChange={setValues}
            defaultValue={data.subCategoryName}
            name="subCateName"
            id="subCateName"
            size="lg"
            label="Tên danh mục con"
            required
          />
        </MDBValidationItem>
        <Form.Group as={Col} controlId="formGridState">
          <Form.Label>Danh mục cha</Form.Label>
          <Form.Select
            defaultValue={data.categoryParentId}
            name="categoryParentId"
            onChange={setValues}
          >
            <option>
              Hiện tại thuộc: {data.categoryParentName}
            </option>
            {categoriesData &&
              categoriesData.map((item) => (
                <option key={item.categoryId} value={item.categoryId}>
                  {item.categoryName}
                </option>
              ))}
          </Form.Select>
        </Form.Group>
        <MDBValidationItem tooltip className="col-md-12">
          <MDBTextArea
            onChange={setValues}
            defaultValue={data.description}
            name="description"
            id="description"
            label="Mô tả"
            size="lg"
          />
        </MDBValidationItem>
        <div className="col-12">
          <MDBBtn type="submit">Xong</MDBBtn>
        </div>
      </MDBValidation>
    </React.Fragment>
  );
}
export default EditSubCategoryForm;
