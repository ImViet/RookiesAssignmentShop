import React, { useEffect, useState } from "react";
import { getCategorySelect } from "../../../api/Category";
import { Form, Col } from "react-bootstrap";
import {
  MDBValidation,
  MDBValidationItem,
  MDBInput,
  MDBBtn,
  MDBTextArea,
} from "mdb-react-ui-kit";
function AddSubCategoryForm({ onSubmit }) {
  const [subCate, setSubCate] = useState({
    subCateName: "",
    description: "",
    categoryId: "0",
  });
  const [categoriesData, setCatesData] = useState();
  function handleSubmit(e) {
    if(subCate.categoryId === "0")
    {
        alert("Vui lòng chọn danh mục !!!");
    }
    if (subCate.subCateName !== "" && subCate.categoryId !== "0") {
      e.preventDefault();
      onSubmit(subCate);
    } else console.log(subCate.categoryId);
  }
  const setValues = (e) => {
    setSubCate((previousState) => {
      return { ...previousState, [e.target.name]: e.target.value };
    });
  };

  useEffect(() => {
    getCategorySelect()
      .then((res) => {
        setCatesData(res);
      })
      .catch((err) => console.log(err));
  }, []);

  return (
    <React.Fragment>
      <MDBValidation onSubmit={handleSubmit} className="row g-3" >
        <MDBValidationItem tooltip feedback="Vui lòng nhập tên danh mục" invalid className="col-md-12">
          <MDBInput
            onChange={setValues}
            name="subCateName"
            id="subCateName"
            size="lg"
            label="Tên danh mục con"
            maxLength={50}
            required
          />
        </MDBValidationItem>
        <Form.Group as={Col} feedback="Vui lòng chọn danh mục"  controlId="formGridState">
          <Form.Label>Danh mục cha</Form.Label>
          <Form.Select
            defaultValue={subCate.categoryId}
            name="categoryId"
            onChange={setValues}
          >
            <option selected value="0" disabled>
              Chọn...
            </option>
            {categoriesData &&
              categoriesData.map((item) => (
                <option key={item.categoryId} value={item.categoryId}>
                  {item.categoryName}
                </option>
              ))}
          </Form.Select>
        </Form.Group>
        <MDBValidationItem tooltip feedback="Được" invalid className="col-md-12">
          <MDBTextArea
            onChange={setValues}
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
export default AddSubCategoryForm;
