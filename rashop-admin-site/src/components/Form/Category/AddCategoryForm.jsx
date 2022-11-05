import { useState } from "react";
import { postCategoryAPI } from "../../../api/Category";
import {
  MDBValidation,
  MDBValidationItem,
  MDBInput,
  MDBBtn,
  MDBTextArea,
} from "mdb-react-ui-kit";
function AddCategoryForm({ onSubmit }) {
  const [cate, setCate] = useState({
    cateName: "",
    description: "",
    image: "",
  });
  function handleSubmit(e) {
    if (cate.cateName !== "") {
      e.preventDefault();
      console.log(cate);
      postCategoryAPI(cate);
      onSubmit(cate);
    } else console.log("Ko hop le");
  }
  const setValues = (e) => {
    setCate((previousState) => {
      return { ...previousState, [e.target.name]: e.target.value };
    });
  };

  return (
    <MDBValidation onSubmit={handleSubmit} className="row g-3">
      <MDBValidationItem tooltip className="col-md-12">
        <MDBInput
          onChange={setValues}
          name="cateName"
          id="cateName"
          size="lg"
          label="Tên danh mục"
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
        />
      </MDBValidationItem>
      <div className="col-12">
        <MDBBtn type="submit">Xong</MDBBtn>
      </div>
    </MDBValidation>
  );
}
export default AddCategoryForm;
