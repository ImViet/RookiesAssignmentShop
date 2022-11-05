import { Modal, Button } from "react-bootstrap";
import DetailCategoryForm from "../../Form/Category/DetailCategoryForm";

function DetailCategoryModal({status, onClose, data}) {
  return (
    <Modal show={status}>
      <Modal.Header>
        <Modal.Title>Chi tiết</Modal.Title>
      </Modal.Header>
      <Modal.Body>
        <DetailCategoryForm data={data} />
      </Modal.Body>
      <Modal.Footer>
        <Button variant="secondary" onClick={onClose}>Đóng</Button>
      </Modal.Footer>
    </Modal>
  );
}
export default DetailCategoryModal;
