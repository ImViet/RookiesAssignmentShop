import { Modal, Button } from "react-bootstrap";
import AddSubCategoryForm from "../../Form/SubCategory/AddSubCategoryForm";
import { postSubCategoryAPI } from "../../../api/SubCategory";
function AddSubCategoryModal({status, onClose}) {
  const handleSubmit = (category)=>{
    postSubCategoryAPI(category).then(()=>{
    onClose();
    setTimeout(() => {
      alert("Thêm thành công!!!");
    }, 200);
  })
    .catch((err)=>{
      setTimeout(() => {
        alert("Thêm thất bại!!!");
      }, 200);
      console.log(err)});
  }
  return (
    <Modal show={status}>
      <Modal.Header>
        <Modal.Title>Tạo danh mục</Modal.Title>
      </Modal.Header>
      <Modal.Body>
        <AddSubCategoryForm onSubmit={handleSubmit}/>
      </Modal.Body>
      <Modal.Footer>
        <Button variant="secondary" onClick={onClose}>Đóng</Button>
      </Modal.Footer>
    </Modal>
  );
}
export default AddSubCategoryModal;
