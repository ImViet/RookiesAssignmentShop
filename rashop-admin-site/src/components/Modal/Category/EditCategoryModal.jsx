import { Modal, Button } from "react-bootstrap";
import EditCategoryForm from "../../Form/Category/EditCategoryForm";

function EditCategoryModal({status, onClose, data}) {
  return (
    <Modal show={status}>
      <Modal.Header>
        <Modal.Title>Sửa danh mục</Modal.Title>
      </Modal.Header>
      <Modal.Body>
        <EditCategoryForm data={data} />
      </Modal.Body>
      <Modal.Footer>
        <Button variant="secondary" onClick={onClose}>Đóng</Button>
      </Modal.Footer>
    </Modal>
  );
}
export default EditCategoryModal;
