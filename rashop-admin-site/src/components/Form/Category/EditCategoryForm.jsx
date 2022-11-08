import { useEffect, useState } from "react";
import { putCategoryAPI } from "../../../api/Category";
import {
  MDBValidation,
  MDBValidationItem,
  MDBInput,
  MDBBtn,
  MDBTextArea,
} from "mdb-react-ui-kit";
function EditCategoryForm({ data, onSubmit }) {
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
    if (cate.cateName !== "") {
      e.preventDefault();
      console.log(cate);
      putCategoryAPI(cate);
      onSubmit(cate);
    } else console.log("Ko hop le");
  }
  return (
    <MDBValidation onSubmit={handleSubmit} className="row g-3">
      <MDBValidationItem tooltip className="col-md-12">
        <MDBInput
          onChange={setValues}
          name="cateId"
          id="cateId"
          label="Id"
          size="lg"
          defaultValue={data.categoryId}
          required
          disabled
        />
      </MDBValidationItem>
      <MDBValidationItem tooltip className="col-md-12">
        <MDBInput
          onChange={setValues}
          name="cateName"
          id="cateName"
          label="Tên danh mục"
          size="lg"
          maxLength={50}
          defaultValue={data.categoryName}
          required
        />
      </MDBValidationItem>
      <MDBValidationItem tooltip className="col-md-12">
        <MDBTextArea
          onChange={setValues}
          name="description"
          id="description"
          label="Mô tả"
          size="lg"
          defaultValue={data.description}
        />
      </MDBValidationItem>
      <div className="col-12">
        <MDBBtn type="submit">Xong</MDBBtn>
      </div>
    </MDBValidation>
  );
}
export default EditCategoryForm;
