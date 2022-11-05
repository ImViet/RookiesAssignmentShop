import { Modal, Button } from "react-bootstrap";
import AddCategoryForm from "../../Form/Category/AddCategoryForm";

function AddCategoryModal({status, onClose}) {
  return (
    <Modal size="lg" show={status}>
      <Modal.Header>
        <Modal.Title>Tạo danh mục</Modal.Title>
      </Modal.Header>
      <Modal.Body>
        <AddCategoryForm onSubmit={()=>onClose()} />
      </Modal.Body>
      <Modal.Footer>
        <Button variant="secondary" onClick={onClose}>Đóng</Button>
      </Modal.Footer>
    </Modal>
  );
}
export default AddCategoryModal;
