import { Modal, Button } from "react-bootstrap";
import AddCategoryForm from "../../Form/Category/AddCategoryForm";
import { postCategoryAPI } from "../../../api/Category";
function AddCategoryModal({status, onClose}) {
  const handleSubmit = (product)=>{
    postCategoryAPI(product).then(()=>{
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
    <Modal size="lg" show={status}>
      <Modal.Header>
        <Modal.Title>Tạo danh mục</Modal.Title>
      </Modal.Header>
      <Modal.Body>
        <AddCategoryForm onSubmit={handleSubmit} />
      </Modal.Body>
      <Modal.Footer>
        <Button variant="secondary" onClick={onClose}>Đóng</Button>
      </Modal.Footer>
    </Modal>
  );
}
export default AddCategoryModal;
