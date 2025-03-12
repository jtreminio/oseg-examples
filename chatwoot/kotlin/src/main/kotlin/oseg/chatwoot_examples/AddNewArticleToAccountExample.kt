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
class AddNewArticleToAccountExample
{
    fun addNewArticleToAccount()
    {
        ApiClient.apiKey["userApiKey"] = "USER_API_KEY"

        val articleCreateUpdatePayload = ArticleCreateUpdatePayload(
            content = null,
            position = null,
            status = null,
            title = null,
            slug = null,
            views = null,
            portalId = null,
            accountId = null,
            authorId = null,
            categoryId = null,
            folderId = null,
            associatedArticleId = null,
        )

        try
        {
            val response = HelpCenterApi().addNewArticleToAccount(
                accountId = null,
                portalId = null,
                _data = articleCreateUpdatePayload,
            )

            println(response)
        } catch (e: ClientException) {
            println("4xx response calling HelpCenterApi#addNewArticleToAccount")
            e.printStackTrace()
        } catch (e: ServerException) {
            println("5xx response calling HelpCenterApi#addNewArticleToAccount")
            e.printStackTrace()
        }
    }
}
