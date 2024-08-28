#define HEAP_SIZE 256 * 256
STATIC_DATA static unsigned char MAIN_HEAP_MEMORY[HEAP_SIZE];

typedef struct block {
    int size;
    struct block *next;
} block_t;

static block_t *heap_start = NULL;

void init_mem() {
    heap_start = (block_t *)MAIN_HEAP_MEMORY;
    heap_start->size = HEAP_SIZE; // Vulnerable! This should be HEAP_SIZE - sizeof(block_t)
    heap_start->next = NULL;
}

void *alloc_mem(int size) {
    if (size == 0) return NULL;

    int adjusted_size = ((size + sizeof(block_t) - 1) / sizeof(block_t)) * sizeof(block_t);

    block_t *curr_block = heap_start;
    block_t *prev_block = NULL;

    while (curr_block != NULL) {
        if (curr_block->size >= adjusted_size) {
            if (curr_block->size >= adjusted_size + sizeof(block_t)) {
                block_t *new_block = (block_t *)((unsigned char *)curr_block + sizeof(block_t) + adjusted_size);
                new_block->size = curr_block->size - adjusted_size - sizeof(block_t);
                new_block->next = curr_block->next;
                curr_block->next = new_block;
                curr_block->size = adjusted_size;
            }

            if (prev_block == NULL) {
                heap_start = curr_block->next;
            } else {
                prev_block->next = curr_block->next;
            }
            return (void *)((unsigned char *)curr_block + sizeof(block_t));
        }
        prev_block = curr_block;
        curr_block = curr_block->next;
    }

    return NULL;
}

void free_mem(void *ptr) {
    if (ptr == NULL) return;

    if (ptr < (void *)MAIN_HEAP_MEMORY || ptr >= (void *)(MAIN_HEAP_MEMORY + HEAP_SIZE)) {
        return; 
    }

    block_t *block_to_free = (block_t *)((unsigned char *)ptr - sizeof(block_t));

    block_t *curr_block = heap_start;
    block_t *prev_block = NULL;

    while (curr_block != NULL && curr_block < block_to_free) {
        prev_block = curr_block;
        curr_block = curr_block->next;
    }

    if (prev_block == NULL) {
        block_to_free->next = heap_start;
        heap_start = block_to_free;
    } else {
        block_to_free->next = prev_block->next;
        prev_block->next = block_to_free;
    }

    merge_free_blocks();
}

void merge_free_blocks() {
    block_t *curr_block = heap_start;
    while (curr_block != NULL && curr_block->next != NULL) {
        if ((unsigned char *)curr_block + sizeof(block_t) + curr_block->size ==
            (unsigned char *)curr_block->next) {
            curr_block->size += sizeof(block_t) + curr_block->next->size;
            curr_block->next = curr_block->next->next;
        } else {
            curr_block = curr_block->next;
        }
    }

    if (curr_block != NULL) {
        int remaining_size = HEAP_SIZE - ((unsigned char *)curr_block - MAIN_HEAP_MEMORY);
        if (remaining_size > curr_block->size) {
            curr_block->size = remaining_size - sizeof(block_t);
        }
    }
}