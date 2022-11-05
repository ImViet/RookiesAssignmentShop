import { Modal, Button } from "react-bootstrap";
import AddSubCategoryForm from "../../Form/SubCategory/AddSubCategoryForm";

function AddSubCategoryModal({status, onClose}) {
  return (
    <Modal show={status}>
      <Modal.Header>
        <Modal.Title>Tạo danh mục</Modal.Title>
      </Modal.Header>
      <Modal.Body>
        <AddSubCategoryForm onSubmit={()=>onClose()}/>
      </Modal.Body>
      <Modal.Footer>
        <Button variant="secondary" onClick={onClose}>Đóng</Button>
      </Modal.Footer>
    </Modal>
  );
}
export default AddSubCategoryModal;
