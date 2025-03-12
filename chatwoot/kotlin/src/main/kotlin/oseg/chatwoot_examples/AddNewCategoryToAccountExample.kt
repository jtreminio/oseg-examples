package oseg.chatwoot_examples

import com.chatwoot.client.infrastructure.*
import com.chatwoot.client.apis.*
import com.chatwoot.client.models.*

import java.io.File
import java.time.LocalDate
import java.time.OffsetDateTime
import kotlin.collections.ArrayList
import kotlin.collections.List
import kotlin.collections.Map
import com.squareup.moshi.adapter

@ExperimentalStdlibApi
class AddNewCategoryToAccountExample
{
    fun addNewCategoryToAccount()
    {
        ApiClient.apiKey["userApiKey"] = "USER_API_KEY"

        val categoryCreateUpdatePayload = CategoryCreateUpdatePayload(
            description = null,
            locale = "en/es",
            name = null,
            slug = null,
            position = null,
            portalId = null,
            accountId = null,
            associatedCategoryId = null,
            parentCategoryId = null,
        )

        try
        {
            val response = HelpCenterApi().addNewCategoryToAccount(
                accountId = null,
                portalId = null,
                _data = categoryCreateUpdatePayload,
            )

            println(response)
        } catch (e: ClientException) {
            println("4xx response calling HelpCenterApi#addNewCategoryToAccount")
            e.printStackTrace()
        } catch (e: ServerException) {
            println("5xx response calling HelpCenterApi#addNewCategoryToAccount")
            e.printStackTrace()
        }
    }
}
