import { Button, Form } from "react-bootstrap";
import {
  MDBValidation,
  MDBValidationItem,
  MDBInput,
  MDBBtn,
  MDBTextArea,
} from "mdb-react-ui-kit";
function DetailCategoryForm({data}) {
  return (
    <MDBValidation className='row g-3'>
      <MDBValidationItem tooltip className='col-md-12'>
      <MDBInput
        name='cateId'
        id='cateId'
        size="lg"
        label='ID'
        defaultValue={data.categoryId}
        required
      />
    </MDBValidationItem>
    <MDBValidationItem tooltip className='col-md-12'>
      <MDBInput
        name='cateName'
        id='cateName'
        size="lg"
        label='Tên danh mục'
        defaultValue={data.categoryName}
        required
      />
    </MDBValidationItem>
    <MDBValidationItem tooltip className='col-md-12'>
      <MDBTextArea
        name='description'
        id='description'
        label='Mô tả'
        size="lg"
        defaultValue={data.description}
      />
    </MDBValidationItem>
  </MDBValidation>
  );
}
export default DetailCategoryForm;
